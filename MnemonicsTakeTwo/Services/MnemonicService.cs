using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MnemonicsTakeTwo.Data;


namespace MnemonicsTakeTwo.Services
{
    public class MnemonicService : IMnemonicService
    {
        private readonly ApplicationDbContext _context;

        public MnemonicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mnemonic>> GetMnemonicsAsync()
        {
            return await _context.Mnemonics.ToListAsync();
        }

        public async Task<Mnemonic> GetMnemonicByIdAsync(int id)
        {
            return await _context.Mnemonics.FindAsync(id);
        }

        public async Task<int> AddMnemonicAsync(Mnemonic mnemonic)
        {
            _context.Mnemonics.Add(mnemonic);
            await _context.SaveChangesAsync();
            return mnemonic.Id;
        }

        public async Task<Mnemonic> UpdateMnemonicAsync(Mnemonic mnemonic)
        {
            _context.Entry(mnemonic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return mnemonic;
        }

        public async Task DeleteMnemonicAsync(int id)
        {
            var mnemonic = await _context.Mnemonics.FindAsync(id);
            if (mnemonic != null)
            {
                _context.Mnemonics.Remove(mnemonic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddCategoryMnemonicAsync(CategoryMnemonic categoryMnemonic)
        {
            _context.CategoryMnemonics.Add(categoryMnemonic);
            await _context.SaveChangesAsync();
        }

        public async Task AddRequestedMnemonicAsync(RequestedMnemonic requestedMnemonic) // Implement this method
        {
            _context.RequestedMnemonics.Add(requestedMnemonic);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RequestedMnemonic>> GetRequestedMnemonicsAsync()
        {
            return await _context.RequestedMnemonics
                .Include(rm => rm.Mnemonic)
                .Include(rm => rm.User)
                .ToListAsync();
        }

        public async Task ApproveMnemonicAsync(int mnemonicId)
        {
            var mnemonic = await _context.Mnemonics.FindAsync(mnemonicId);
            if (mnemonic != null)
            {
                mnemonic.IsApproved = true;
                _context.Mnemonics.Update(mnemonic);
                await _context.SaveChangesAsync();

                var requestedMnemonic = await _context.RequestedMnemonics.FirstOrDefaultAsync(rm => rm.MnemonicId == mnemonicId);
                if (requestedMnemonic != null)
                {
                    _context.RequestedMnemonics.Remove(requestedMnemonic);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task RejectMnemonicAsync(int mnemonicId)
        {
            var mnemonic = await _context.Mnemonics.FindAsync(mnemonicId);
            if (mnemonic != null)
            {
                _context.Mnemonics.Remove(mnemonic);
                await _context.SaveChangesAsync();

                var requestedMnemonic = await _context.RequestedMnemonics.FirstOrDefaultAsync(rm => rm.MnemonicId == mnemonicId);
                if (requestedMnemonic != null)
                {
                    _context.RequestedMnemonics.Remove(requestedMnemonic);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<RequestedMnemonic> GetRequestedMnemonicByIdAsync(int mnemonicId)
        {
            var requestedMnemonic = await _context.RequestedMnemonics.FirstOrDefaultAsync(rm => rm.MnemonicId == mnemonicId);
            return requestedMnemonic;
        }
    }
}

